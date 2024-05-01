from pydantic import BaseModel


class CryptoDataRequest(BaseModel):
    cryptoId: str
    days: str
    interval: str
