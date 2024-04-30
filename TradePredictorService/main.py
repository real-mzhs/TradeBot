from http.client import HTTPResponse

from fastapi import FastAPI
from starlette import status
from binance.client import AsyncClient
from binance import ThreadedWebsocketManager
import logging
from models.trade_signal_request import TradeSignalRequest
from train_model import setup_modal
from utils.message_processing import process_message

logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

app = FastAPI()

client: AsyncClient
model, scaler = setup_modal()


@app.get("/")
async def root():
    return {"message": "Hello World"}


@app.post("/initiate-trading")
async def initiate_trading(request: TradeSignalRequest):
    global client

    client = AsyncClient(request.api_key, request.api_secret, testnet=True)

    bs = ThreadedWebsocketManager()
    bs.start_trade_socket(lambda msg: process_message(client, msg, model, scaler), request.symbol)
    bs.start()

    return HTTPResponse(status_code=status.HTTP_200_OK)
