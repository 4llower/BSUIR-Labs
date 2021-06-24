from time import time


def expired_cache(timeout):
    def decorator(func):
        func.cache = {}

        def wrapper(*args, **kwargs):
            serialized = args + tuple(kwargs.items())
            if serialized not in func.cache or time() - func.cache[serialized]['time'] > timeout:
                result = func(*args, **kwargs)
                func.cache[serialized] = {
                    'result': result,
                    'time': time()
                }
            return func.cache[serialized]['result']
        return wrapper
    return decorator


counter = 0


@expired_cache(500)
def add(a, b):
    global counter
    counter += 1
    return a + b


print(add(5, 5))
print(add(5, 5))
print(add(5, 5))
print(add(2, 5))
print(add(2, 3))
print(add(2, 5))
print(counter)
