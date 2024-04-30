from typing import List
from pydantic import BaseModel
from models.rate_limit import RateLimit
from models.ticker_result import TickerResult


class TickerResponse(BaseModel):
    id: str
    status: int
    result: TickerResult
    rateLimits: List[RateLimit]
