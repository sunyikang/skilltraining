

class Calculator():

    def add(self, x, y):
        return x + y

    def subtract(self, x, y):
        return x - y

    def divide(self, x, y):
        if y == 0:
            return "y cannot be 0"
        return x / y

    def multiple(self, x, y):
        return x * y


cal = Calculator()
print(cal.add(1, 2))
print(cal.subtract(1, 2))
print(cal.divide(1, 2))
print(cal.divide(1, 0))
print(cal.multiple(1, 2))
