from pydantic import BaseModel


class GetCryptoPrice(BaseModel):
    cryptoId: str
    days: str
    interval: str
