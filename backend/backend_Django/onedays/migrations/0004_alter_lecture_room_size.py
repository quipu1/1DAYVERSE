# Generated by Django 3.2.1 on 2021-11-11 02:34

import django.core.validators
from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('onedays', '0003_auto_20211029_1359'),
    ]

    operations = [
        migrations.AlterField(
            model_name='lecture',
            name='room_size',
            field=models.PositiveIntegerField(validators=[django.core.validators.MinValueValidator(1), django.core.validators.MaxValueValidator(20)]),
        ),
    ]