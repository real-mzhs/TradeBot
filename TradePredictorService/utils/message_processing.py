import logging
import math
import torch
from binance import AsyncClient
from binance.exceptions import BinanceOrderException, BinanceAPIException
from config import Config
from models.ticker_response import TickerResponse
from models.ticker_result import TickerResult


# Function to preprocess data
def preprocess_data(msg: TickerResult, scaler):
    try:
        price = float(msg['p'])
        scaled_price = scaler.transform([[price]])
        return torch.tensor(scaled_price, dtype=torch.float).unsqueeze(0)
    except KeyError as e:
        logging.error(f"Key error in message data: {e}")
        return torch.zeros(1, 1, dtype=torch.float)


# Function to calculate quantity
def calculate_quantity(client: AsyncClient, symbol='BTCUSDT', risk_factor=Config.RISK_FACTOR):
    try:
        account_details = client.get_account()
        free_balance = next((item for item in account_details['balances'] if item["asset"] == symbol[:-4]), None)['free']
        free_balance = float(free_balance)
        quantity = free_balance * risk_factor
        return adjust_quantity_to_meet_requirements(quantity, symbol)

    except Exception as e:
        logging.error(f"Error calculating quantity: {e}")
        return 0


# Function to adjust quantity to meet requirements
def adjust_quantity_to_meet_requirements(client: AsyncClient, quantity, symbol='BTCUSDT'):
    try:
        symbol_info = client.get_symbol_info(symbol)
        lot_size_filter = next((filter for filter in symbol_info['filters'] if filter['filterType'] == 'LOT_SIZE'),
                               None)
        if lot_size_filter:
            min_qty = float(lot_size_filter['minQty'])
            max_qty = float(lot_size_filter['maxQty'])
            step_size = float(lot_size_filter['stepSize'])

            quantity = max(min_qty, min(quantity, max_qty))
            step_size_scale = round(-math.log(step_size, 10)) # TODO: step_size_scale is not being used
            quantity = round(quantity / step_size) * step_size
            quantity = round(quantity, Config.LOT_SIZE_ROUNDING)

            return quantity
        else:
            logging.error(f"LOT_SIZE filter not found for symbol: {symbol}")
            return 0
    except Exception as e:
        logging.error(f"Error adjusting quantity: {e}")
        return 0

# Function to process trade message
# def process_message(client: AsyncClient, msg, model, scaler):
#     try:
#         if msg['e'] == 'trade':
#             data = preprocess_data(msg, scaler)
#             prediction = model(data)
#             if prediction.item() > Config.BUY_THRESHOLD:
#                 # Adjusted to potentially buy more aggressively
#                 order = client.order_market_buy(symbol=Config.CRYPTO_SYMBOL,
#                                                 quantity=calculate_quantity(Config.CRYPTO_SYMBOL,
#                                                                             risk_factor=Config.RISK_FACTOR * 2))
#                 logging.info(f"Buy order placed: {order}")
#             elif prediction.item() < Config.SELL_THRESHOLD:
#                 # Adjusted to potentially sell more aggressively
#                 order = client.order_market_sell(symbol=Config.CRYPTO_SYMBOL,
#                                                  quantity=calculate_quantity(Config.CRYPTO_SYMBOL,
#                                                                              risk_factor=Config.RISK_FACTOR * 2))
#                 logging.info(f"Sell order placed: {order}")
#     except (BinanceAPIException, BinanceOrderException) as e:
#         logging.error(f"Binance error: {e}")
#     except Exception as e:
#         logging.error(f"Error processing message: {e}")

def process_message(client: AsyncClient, msg: TickerResponse, model, scaler):
    try:
        data = preprocess_data(msg.result, scaler)
        prediction = model(data)
        if prediction.item() > Config.BUY_THRESHOLD:
            # Adjusted to potentially buy more aggressively
            # order = client.order_market_buy(symbol=Config.CRYPTO_SYMBOL,quantity=calculate_quantity(Config.CRYPTO_SYMBOL, risk_factor=Config.RISK_FACTOR * 2))
            logging.info(f"Buy order placed: {msg.result.lastPrice}")
        elif prediction.item() < Config.SELL_THRESHOLD:
            logging.info(f"Sell order placed: {msg.result.lastPrice}")
    except (BinanceAPIException, BinanceOrderException) as e:
        logging.error(f"Binance error: {e}")
    except Exception as e:
        logging.error(f"Error processing message: {e}")
