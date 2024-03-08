def f(n):
    if n > 1:
        if (n ** 0.5) == int(n ** 0.5):
            return 1 + f(int(n ** 0.5))
        elif n % 2 == 0:
            return 1 + f(n // 2)
        else:
            return 1 + f(n * 2)
    elif n < 1:
        return 1 + f(n + 2)
    else:
        return 0
f(10000)