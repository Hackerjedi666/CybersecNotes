import requests


url = "http://83.136.250.104:42896/index.php?id=1"

x = requests.get(url)
print(x.text)