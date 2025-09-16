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

**Invariants** are the property of the smart contracts taht always hold and always should be true.


## GAS

The transaction fee is the amount rewarded to the block producer for processing the transaction. It is paid in Ether or GWei.

The gas price, also defined in either Ether or GWei, is the cost per unit of gas specified for the transaction. The higher the gas price, the greater the chance of the transaction being included in a block.

*Gas price is not to be confused with gas. While gas refers to the computational effort required to execute the transaction, gas price is the cost per unit of that effort.*


## The Role of Nodes in Blockchain

Blockchains are run by a group of different nodes, sometimes referred to as miners or validators, depending on the network. These miners get incentivized for running the blockchain by earning a fraction of the native blockchain currency for processing transactions. 

For instance, Ethereum miners get paid in Ether, while those in Polygon get rewarded in MATIC, the native token of Polygon. This remuneration encourages people to continue running these nodes.


## Understanding Gas in Transactions

The higher a transaction's complexity, the more gas it requires. 

For instance, common transactions like sending Ether are less complex and require relatively small amounts of gas. However, more sophisticated transactions like minting an NFT, deploying a smart contract, or depositing funds into a DeFi protocol, demand more gas due to their complexity.

The total transaction fee can be calculated by multiplying the gas used with the gas price in Ether (not GWei). Therefore, Transaction fee = gasPrice * gasUsed.

## Hashing fuctions

Ethereum, uses its own version of a hashing algorithm (Keccak256) that isn't exactly SHA-256 but belongs to the SHA family. This doesn't change things significantly here as we're primarily concentrating on the concept of hashing.

# Zero knowledge proofs and SNARKS

## What are they?

Proving something is true without revealing nothing about that particlar information is the overview of zero knowledge. Basically revealing nothing about the verifier.

SNARK achieves the same but with better cost to the verifier like saving the time and communication etc (basically watching the performace aspect of it). Its all about how efficient the verifier is.






# EVM

[I studied from here](https://www.youtube.com/watch?v=kCswGz9naZg)

Etherium has a world state that changes when a new block is mined in the blockchain.

The way the transition of state happens is with the help of evm.

The whole world state just contains a bunch of accounts. There are two types of accounts which are externally owned accounts by a person(the metamask, phantom etc) and contracts accounts.

Externally owned accounts are controlled by private keys and don't contain any evm codes.

Contract based accounts contains the evm code and controlled by it.






# Defi

## AMMs (Automated market makers)

It enabled permissionless trading all over the internet.

### Constant product amm

X.Y = K

X and Y are amount of tokens and K is the measure of pool's liquidity.








# Web3 security 101

## Things to consider when making External Calls in smart contracts

1) Re-entrancy
2) DOS (Denial of service)
3) Gas Griefing
4) Return Values

## Re-entrancy

1) Classic Re-entrancy

 