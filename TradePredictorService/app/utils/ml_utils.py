import logging
import torch
import torch.nn as nn
import torch.optim as optim
from app.config import Config


# Function to train the model
def train_model(model, x_train, y_train):
    criterion = nn.MSELoss()
    optimizer = optim.Adam(model.parameters(), lr=Config.LEARNING_RATE)
    scheduler = optim.lr_scheduler.StepLR(optimizer, step_size=30, gamma=0.1)

    x_train_tensor = torch.tensor(x_train, dtype=torch.float).unsqueeze(1)
    y_train_tensor = torch.tensor(y_train, dtype=torch.float).unsqueeze(1)

    for epoch in range(Config.NUM_EPOCHS):
        optimizer.zero_grad()
        outputs = model(x_train_tensor)
        loss = criterion(outputs, y_train_tensor)
        loss.backward()
        optimizer.step()
        scheduler.step()
        logging.info(f'Epoch {epoch + 1}, Loss: {loss.item()}')


# Function to evaluate the model
def evaluate_model(model, x_test, y_test):
    criterion = nn.MSELoss()
    x_test_tensor = torch.tensor(x_test, dtype=torch.float).unsqueeze(1)
    predictions = model(x_test_tensor)
    mse = criterion(predictions, torch.tensor(y_test, dtype=torch.float).unsqueeze(1))
    logging.info(f'Test MSE: {mse.item()}')
