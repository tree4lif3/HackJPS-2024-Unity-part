import pandas as pd
import numpy as np
from tensorflow import *
from tensorflow import keras
from keras.models import Sequential
from keras.layers import Dense
from keras.layers import Normalization
from keras.losses import MeanSquaredError
from keras.optimizers import Adam

training = pd.read_csv('all_stocks_5yr.csv')

training.dropna(inplace=True)


target = training['close']

numeric_feature_names = ['open','high', 'low', 'volume']
numeric_features = training[numeric_feature_names]
numeric_features = convert_to_tensor(numeric_features)

normalizer = Normalization(axis=-1)
normalizer.adapt(numeric_features)



def get_model():
    model = Sequential([
        normalizer,
        Dense(8, activation="relu"),
        Dense(8, activation="relu"),

        Dense(1)
    ])
    model.compile(optimizer=Adam(),
                  loss=MeanSquaredError(),
                  metrics=['mse'])
    return model

model = get_model()
model.fit(numeric_features, target, epochs=15,
          batch_size= 32,
          validation_split=0.2)

predictions = model.predict(numeric_features)
closelist = predictions.flatten().tolist()
training['close'] = closelist


target = training['opinion']

numeric_feature_names = ['open','high', 'close', 'low', 'volume']
numeric_features = training[numeric_feature_names]
numeric_features = convert_to_tensor(numeric_features)

normalizer = Normalization(axis=-1)
normalizer.adapt(numeric_features)



def get_model():
    model = Sequential([
        normalizer,
        Dense(8, activation="relu"),
        Dense(8, activation="relu"),
        Dense(1)
    ])
    model.compile(optimizer=Adam(),
                  loss=MeanSquaredError(),
                  metrics=['mse', 'accuracy'])
    return model

model = get_model()
model.fit(numeric_features, target, epochs= 15,
          batch_size= 32,
          validation_split=0.2)
predictions = model.predict(numeric_features)
opinionlist = list(predictions.flatten())
print(opinionlist)


