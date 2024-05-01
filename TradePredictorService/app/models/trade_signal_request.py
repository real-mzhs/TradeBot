from pydantic import BaseModel


class TradeSignalRequest(BaseModel):
    api_key: str
    api_secret: str
    symbol: str
    side: str
    quantity: float
