# app/__init__.py

# third-party imports
from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_login import LoginManager
from flask_migrate import Migrate
from flask_bootstrap import Bootstrap

# local imports
from config import app_config

# db variable initialization
db = SQLAlchemy()
login_manager = LoginManager()

def create_app(config_name):
    #Todo: Create Flask Instance

    #Todo: Get config from object
    
    #Todo: Get config from pyfile
    
    Bootstrap(app)
    db.init_app(app)

    login_manager.init_app(app)
    login_manager.login_message = "You must be logged in to access this page."
    login_manager.login_view = "auth.login"

    migrate = Migrate(app, db)

    from app import models

    # Register Blueprint

    # Temporary route
    @app.route('/')
    def hello_world():
        return 'Hello, World!'

    return app
