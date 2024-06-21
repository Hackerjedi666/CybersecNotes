# (OSWP)Offensive Security Wireless professional

# Wireless Attacks

- Infrastructure is the term used to describe and organization or the relationship between client (station) and access points(routers).
- Wireless Distribution System is a way to connect multiple APs without Ethernet cables between them in order to create a single network.
- Monitor Mode is not an architecture, per se, but a mode used by wireless cards that will help us capture Wi-Fi frames and inject packets during a penetration test.

## Infrastructure

So there is atleast one router and one client. These two together form a basic service check (BSS).
The AP is usually connected to a wired network, called the Distribution System (DS).
When a set of two or more wireless APs are connected to the same wired network, we call this an Extended Service Set (ESS).

## Wireless distributed

This is just as the name suggests, instead of cables we use distrubuted system which connects to the APs over wifi (without cables) but there is a downside to it. We are restricted to a certain area in which that APs is gonna provide signal to the client and this is called (BSA) Basic Service Area.

So APs communicate using electromagnetic waves and they usually use two frequencies 2.4 and 5.
In both of these bands there are multiple channels through which we can control the interference like in 2.4 there are 14 channels.
But most of them overlap with each other so its advised to use the channel 1,6 and 11. 2.4 ghz frequency is used for longer ranges but speed is comparitvely slower than 5ghz.

The two most imortant piece of information that is traveled in the wireless medium is SSID (name of the network) and BSSID (mac address of it).

## Monitor Mode

Monitor mode is not a wireless mode or architecture scheme, but rather the state of a wireless device that allows it to monitor all Wi-Fi signals within its range.

# Wireless Encryption

Wi-Fi works over radio waves, which means it is subject to eavesdropping and therefore, encryption has to be used to protect the transmitted data.

Wired Equivalent Privacy (WEP)1 was created when the 802.11 standard was released in order to give privacy features similar to those found in wired networks.

As soon as flaws were discovered in WEP (WEP can be cracked in under a minute), the IEEE created a new group called 802.11i aimed at improving Wi-Fi security. Wi-Fi Protected Access (WPA)2 superseded WEP in 2003, followed by WPA2 in 2004 (802.11i standard).

# Cracking WPA/WPA2

There are two types of authentication methods in this encryption

- PSK (pre shared key authentication)
- Enterprise Networks

we need to capture a WPA 4-way handshake between the AP and a real client. This is a process that we will use throughout the course. The 4-way handshake contains the necessary information we need to crack the passphrase.

We can get a 4way handshake using following steps:

first find which network to target using airodump:

```bash
sudo airodump-ng -c 3 -w wpa --essid wifu --bssid 34:08:04:09:3D:38 wlan0mon
```

Then using aireplay-ng deauth one or all the clients on that network:

```bash
sudo aireplay-ng -0 1 -a 34:08:04:09:3D:38 -c 00:18:4D:1D:A8:1F wlan0mon
```

Now when that client will attempt to reconnect with the network the 4 way handshake will be captured.

Make sure to let the airodump keep running for some time after capturing the handshake because that data might help use crack the password.

Then using a custom wordlist crack the 4 way handshake with the aircrack-ng:

```bash
aircrack-ng -w /usr/share/john/password.lst -e wifu -b 34:08:04:09:3D:38 wpa-01.cap
```

## Cracking passwords for WPA Enterprise

The above WPA/WPA2 network we saw were using PSK authetication, one shared key is used for authentication and router is the one that manages authentication.

WPA Enterprise is another form of authetication.

Each user gets their own key to connect to the network.

Authentication is managed by a central server (Radius server) not by a router.
