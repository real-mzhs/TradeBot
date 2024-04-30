from pydantic import BaseModel


class RateLimit(BaseModel):
    rateLimitType: str
    interval: str
    intervalNum: int
    limit: int
    count: int
