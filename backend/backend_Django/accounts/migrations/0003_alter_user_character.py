# Generated by Django 3.2.1 on 2021-11-18 04:37

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('accounts', '0002_alter_character_character_image'),
    ]

    operations = [
        migrations.AlterField(
            model_name='user',
            name='character',
            field=models.ForeignKey(blank=True, default=1, null=True, on_delete=django.db.models.deletion.CASCADE, to='accounts.character'),
        ),
    ]
