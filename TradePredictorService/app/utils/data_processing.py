import concurrent.futures
import logging
import numpy as np
import pandas as pd
import requests
import torch
from functools import partial
from ta import add_all_ta_features
from transformers import AutoTokenizer, AutoModel
from app.models.crypto_data_request import CryptoDataRequest


# Function to fetch crypto prices with indicators
def fetch_crypto_prices_with_indicators(request: CryptoDataRequest) -> pd.DataFrame:
    try:
        url = f'https://api.coingecko.com/api/v3/coins/{request.cryptoId}/market_chart'
        params = {'vs_currency': 'usd', 'days': request.days, 'interval': request.interval}
        response = requests.get(url, params=params)
        data = response.json()
        prices = data['prices']

        df = pd.DataFrame(prices, columns=['timestamp', 'price'])
        df['date'] = pd.to_datetime(df['timestamp'], unit='ms')
        df = df.drop(columns='timestamp')
        df = add_all_ta_features(
            df,
            open="price",
            high="price",
            low="price",
            close="price",
            volume="price",
            fillna=True
        )

        return df

    except Exception as e:
        logging.error(f"Error fetching price data: {e}")
        return pd.DataFrame()


# Function to get combined embeddings for texts
def get_combined_embeddings(texts):
    try:
        tokenizer_bitcoin = AutoTokenizer.from_pretrained("huggingtweets/bitcoin")
        model_bitcoin = AutoModel.from_pretrained("huggingtweets/bitcoin")
        tokenizer_cryptobert = AutoTokenizer.from_pretrained("ElKulako/cryptobert")
        model_cryptobert = AutoModel.from_pretrained("ElKulako/cryptobert")
        combined_embeddings = []

        # Function to generate embedding for a single text
        def generate_embedding(text, tokenizer, model):
            inputs = tokenizer(text, return_tensors="pt", padding=True, truncation=True, max_length=512)
            with torch.no_grad():
                outputs = model(**inputs)
            return outputs.last_hidden_state[:, 0, :].squeeze().numpy()

        # Use ThreadPoolExecutor for parallel processing
        with concurrent.futures.ThreadPoolExecutor() as executor:
            # Generate embeddings concurrently for each text
            futures = [executor.submit(partial(generate_embedding, text, tokenizer_bitcoin, model_bitcoin)) for text in texts]
            bitcoin_embeddings = [future.result() for future in concurrent.futures.as_completed(futures)]

            futures = [executor.submit(partial(generate_embedding, text, tokenizer_cryptobert, model_cryptobert)) for text in texts]
            cryptobert_embeddings = [future.result() for future in concurrent.futures.as_completed(futures)]

        # Combine embeddings
        combined_embeddings = [np.concatenate((bitcoin_emb, cryptobert_emb)) for bitcoin_emb, cryptobert_emb in
                               zip(bitcoin_embeddings, cryptobert_embeddings)]

        return np.array(combined_embeddings)

    except Exception as e:
        logging.error(f"Error generating embeddings: {e}")
        return np.empty((0,))
