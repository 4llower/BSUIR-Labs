from functools import lru_cache
from time import time

DEFAULT_TIMEOUT = 5
TIME_PROGRAM_START = time()


def rest_time_to_close():
    return DEFAULT_TIMEOUT - (time() - TIME_PROGRAM_START)


@lru_cache(maxsize=None)
def message_timeout_to_close(timeout):
    print('Program was closed across %.2f' % timeout)


if __name__ == '__main__':
    print('The program was successfully installed')
    while True:
        rest_time = round(rest_time_to_close(), 2)
        if rest_time <= 0:
            break
        else:
            message_timeout_to_close(rest_time)
    print('Bye!')
