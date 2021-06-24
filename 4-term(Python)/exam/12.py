def singleton(cls):
    instances = {}

    def wrapper(*args, **kwargs):
        if cls not in instances:
            instances[cls] = cls(*args, **kwargs)
        return instances[cls]

    return wrapper


@singleton
class Singleton:
    def __init__(self):
        print(228)


a = Singleton()
b = Singleton()

print(a == b)