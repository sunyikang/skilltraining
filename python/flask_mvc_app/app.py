# app.py

import os

from flask_script import Manager
from flask_migrate import Migrate, MigrateCommand
from app import create_app, db

#config_name = os.getenv('FLASK_CONFIG')
config_name = "development"
app = create_app(config_name)

manager = Manager(app)

migrate = Migrate(app, db)

manager.add_command('db', MigrateCommand)

@manager.command
def run():
    '''Run the app'''
    app.run()

@manager.command
def clean():
    '''Clean the compiled Pycache'''
    print("Python __pycache__ have been deleted.")
    import pathlib
    [p.unlink() for p in pathlib.Path('.').rglob('*.py[co]')]
    [p.rmdir() for p in pathlib.Path('.').rglob('__pycache__')]


if __name__ == '__main__':
    manager.run()
