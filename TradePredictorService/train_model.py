from typing import List
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import MinMaxScaler
from config import Config
from models.crypto_data_request import CryptoDataRequest
from models.crypto_hybrid_model import CryptoHybridModel
from utils.data_processing import fetch_crypto_prices_with_indicators, get_combined_embeddings
from utils.ml_utils import train_model, evaluate_model


def setup_modal():
    # Fetch price data and preprocess
    price_data = fetch_crypto_prices_with_indicators(CryptoDataRequest(cryptoId="BTCUSDT", days="max", interval="daily"))
    scaler = MinMaxScaler(feature_range=(0, 1))
    normalized_data = scaler.fit_transform(price_data.drop(columns=['date']))

    # Generate combined embeddings for text data
    combined_embeddings = get_combined_embeddings(Config.TEXTS)

    # Combine features and split data for training and testing
    combined_features = np.hstack((normalized_data[:-1], combined_embeddings[:-1]))
    x_train, x_test, y_train, y_test = train_test_split(
        combined_features, normalized_data[1:, 0], test_size=0.2, ndom_state=42
    )

    # Define and train the model
    model = CryptoHybridModel()
    train_model(model, x_train, y_train)

    # Evaluate the model
    evaluate_model(model, x_test, y_test)

    return model, scaler
