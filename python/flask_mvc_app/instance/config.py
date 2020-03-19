# instance/config.py

"""
Sentitive information goes here
"""
import os
basedir = os.path.abspath(os.path.dirname(__file__))

SECRET_KEY = 'some secret key'
SQLALCHEMY_DATABASE_URI = 'sqlite:///' + os.path.join(basedir, 'main.db')
