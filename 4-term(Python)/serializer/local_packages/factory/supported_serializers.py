from enum import Enum


class SupportedSerializers(Enum):
    YAML = 'YAML'
    JSON = 'JSON'
    PICKLE = 'PICKLE'
    TOML = 'TOML'

    def __str__(self):
        return self.value

    @classmethod
    def values(cls):
        return list(map(lambda c: c.value, cls))
