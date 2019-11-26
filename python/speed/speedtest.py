import timeit

code_to_test = """
from sklearn.cluster import KMeans
import numpy as np
x = np.random.rand(50000, 200)
KMeans().fit(x)
"""

elapsed_time = timeit.timeit(code_to_test, number=1)/1
print(elapsed_time)