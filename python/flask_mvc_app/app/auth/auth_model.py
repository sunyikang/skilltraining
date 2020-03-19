# app/auth/auth_model.py

from flask_wtf import FlaskForm
from wtforms import PasswordField, StringField, SubmitField, ValidationError
from wtforms.validators import DataRequired, Email, EqualTo

from ..models import User


class RegistrationForm(FlaskForm):
    """
    Form for users to create new account
    """


class LoginForm(FlaskForm):
    """
    Form for users to login
    """
    print(__name__ + " invoked")

