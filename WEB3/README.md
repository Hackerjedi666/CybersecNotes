# Everyting about web3 security i am gonna learn...

# Smart contracts

Smart contracts are a set of instructions executed in a decentralized way without the need for a centralized or third party intermediary.

Smart Contract functionality is the primary difference between blockchains like Ethereum and Bitcoin. Technically Bitcoin does have smart contracts but they're intentionally turing incomplete.

## The oracle problem

Smart contracts cannot interact with or access data from the real world. This is known as the Oracle Problem.

Blockchains are deterministic systems, so everything happens withing their small little world. 

To make smart contracts more useful and capable of handling real-world data, they need external data and computation.

Oracles serve this purpose. They are devices or services that provide data to blockchains or run external computation. 

To maintain decentralization, it's necessary to use a decentralized Oracle network rather than relying on a single source. This combination of on-chain logic with off-chain data leads to *hybrid smart contracts*.


* *Chainlink* is a popular decentralized Oracle network that enables smart contracts to access external data and computation.

## Layer 2 Scaling Solutions

As blockchains grow, they face scaling issues. Layer 2, or L2, solutions have been developed to address this. L2 solutions involve other blockchains hooking into the main blockchain, essentially allowing it to scale. There are two primary types of L2 solutions:

* Optimistic Rollups: eg. Optimism, Arbitrum

* Zero-Knowledge Rollups: eg. ZKsync, Polygon ZK EVM


## Common terms

Layer 2: Layer 2 solutions in web3 are technologies built on top of a blockchain (Layer 1) to improve its scalability and efficiency. These solutions handle transactions off the main chain, reducing congestion and fees, and then settle the final state on the main chain. Example: The Lightning Network for Bitcoin.

Dapp (Decentralized Application): A Dapp is an application that runs on a decentralized network, typically a blockchain. It is powered by smart contracts and operates without a central authority. Dapps can serve various purposes, from finance to gaming. Example: Uniswap, a decentralized finance application.

Smart Contract: In web3, a smart contract is a self-executing contract with the terms of the agreement directly written into code. They run on blockchains and automatically execute when predetermined conditions are met, without the need for intermediaries. Example: A smart contract for an escrow service.

Hybrid Smart Contract: Hybrid smart contracts combine on-chain code (running on a blockchain) with off-chain data and computations provided by oracles. This allows the contracts to interact with data and systems outside their native blockchain. Example: A smart contract for insurance that uses real-world data (like weather or flight delays) provided by oracles.

Ethereum/EVM (Ethereum Virtual Machine): Ethereum is a blockchain platform known for its smart contract functionality. *The Ethereum Virtual Machine (EVM)* is its computation engine that executes smart contracts. Ethereum allows developers to build decentralized applications and is the basis for many web3 projects. Example: ERC-20 tokens, a standard for creating fungible tokens on Ethereum.








# Web3 security 101

## Things to consider when making External Calls in smart contracts

1) Re-entrancy
2) DOS (Denial of service)
3) Gas Griefing
4) Return Values