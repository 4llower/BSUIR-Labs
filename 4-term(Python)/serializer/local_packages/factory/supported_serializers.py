from enum import Enum


class SupportedSerializers(Enum):
    YAML = 'YAML'
    JSON = 'JSON',
    PICKLE = 'PICKLE',
    TOML = 'TOML',

    def __str__(self):
        return self.value
