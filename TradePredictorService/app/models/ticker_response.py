from typing import List
from pydantic import BaseModel
from app.models.rate_limit import RateLimit
from app.models.ticker_result import TickerResult


class TickerResponse(BaseModel):
    id: str
    status: int
    result: TickerResult
    rateLimits: List[RateLimit]
