from pydantic import BaseModel


class TickerResult(BaseModel):
    symbol: str
    priceChange: str
    priceChangePercent: str
    weightedAvgPrice: str
    openPrice: str
    highPrice: str
    lowPrice: str
    lastPrice: str
    volume: str
    quoteVolume: str
    openTime: int
    closeTime: int
    firstId: int
    lastId: int
    count: int
