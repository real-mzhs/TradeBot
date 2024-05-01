import torch.nn as nn
import torch.nn.functional as f


class CryptoHybridModel(nn.Module):
    def __init__(self):
        super(CryptoHybridModel, self).__init__()
        self.conv1 = nn.Conv1d(1, 16, kernel_size=3, stride=1, padding=1)
        self.conv2 = nn.Conv1d(16, 32, kernel_size=3, stride=1, padding=1)
        self.lstm = nn.LSTM(32, 64, batch_first=True)
        self.dropout = nn.Dropout(0.5)
        self.fc = nn.Linear(64, 1)

    def forward(self, x):
        x = f.relu(self.conv1(x))
        x = f.max_pool1d(x, 2)
        x = f.relu(self.conv2(x))
        x = f.max_pool1d(x, 2)
        x, _ = self.lstm(x)
        x = self.dropout(x[:, -1, :])
        x = self.fc(x)
        return x
