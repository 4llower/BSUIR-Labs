class MetaSingle(type):
    _instance = None

    def __call__(cls, *args, **kwargs):
        if cls._instance is None:
            cls._instance = super(MetaSingle, cls).__call__(*args, **kwargs)
        return cls._instance


class Singleton(metaclass=MetaSingle):
    def __init__(self):
        print(228)


a = Singleton()
b = Singleton()

print(a == b)
