# RiseSharp
(c) Raj Bandi 2016, Apache 2.0 Licence

App Veyor: [![Build status](https://ci.appveyor.com/api/projects/status/ceylrldf45l3qbi9?svg=true)](https://ci.appveyor.com/project/Rajbandi/risesharp)

#Introduction

Rise meets C#.Net

RiseSharp is cross platform  library based on Rise (https://www.rise.vision) and entirely rewritten in C# without any node.js depedencies. Risesharp core api is a PCL library.  Currently it supports Windows (including windows 8, 10 and windows phone), Linux and Mac, Xamarin mobile. 

### Development Environment

#### Frameworks
1. .Net 4.6
2. Mono.Net (Linux & Mac)

#### Editors
1. Visual Studio 2015 
2. Xamarin Studio 6

#### Third party dependencies
1. NBitcoin
2. Chaos.Nacl
3. Newtonsoft.json
4. NUnit

# Features
- Native Bip32 Mnuemonic passphrase generation.
- Native Rise Address generation from a given BIP32 Mnuemonic passphrase.
- Sign and Verify message bytes with private key. 
- Calculate transaction and dapp bytes.
- Transfer Rise between accounts.
- Vote Delegates with Rise.
- API facade for Rise public api (/api/*) (complete api)
- API facade for Rise peer level api (/peer/*) (partial, see underdevelopment and roadmap)

# Rise api
Every Rise node provides 2 api's. Use RiseSharp api's facade to connect to any Rise node in the network with simple calls and retrieve data. 

1. Public api (/api/*)
2. Peer api (/peer/*)

All the api requests initiated from RiseSharpsupports both synchronous and asynchronous. 

#### Currently supports only outgoing requests to other Rise nodes not vice versa i,e. it doesn't accept api requests from other nodes.

## Public api

RiseSharp supports complete Rise public api (outward only) categorized as below. 

- Accounts (/api/accounts/*)
- Blocks (/api/blocks/*)
- Delegates (/api/delegates/*)
- Loader (/api/loader/*)
- Peers (/api/peers/*)
- Multisignatures (/api/multisignatures)
- Signatures (/api/signatures/*)
- Transactions (/api/transactions/*)

## Peer api
Risesharp supports following peer related api. Still under development

- Peer list (/peer/list)
- Peer blocks (/peer/blocks)
- Peer height (/peer/height) 
- Peer transaction (/peer/transaction)

#### Under development

- Peer blocks common (/peer/blocks/common)
- Peer signatures (/peer/signatures)
- Peer dapp request (/peer/dapp/request)
- Peer dapp message (/peer/dapp/message)


# Under development
- Peer API facade complete.  
- Logic to create new blocks,  transactions, votes.
- DappMan, a dapp manager library for building dapps with or without git.
- DappManCli, a cross platform dapp command line to create, uupdate and remove dapps.


# RoadMap 

I'm working and contributing to this project in my free time. So expect updates anytime. Other developers are most welcome if they want to help in this project.

- Standalone server (as window service or background worker) with api, database, delegates and broadcast to other peers.
- Separate api layer for handling incoming api requests both public and peer from other nodes.
- Windows native client.
- Windows 8, phone & 10 apps.
- Android and IOS(IPhone) native apps ( will be faster than web version).



# Examples

##### More examples in Unit Tests. 

- Generate BIP32 Mneumonic passphrase
```
var secret = CryptoHelper.GenerateSecret(); 
Console.WriteLine(secret); 
//cabbage chief join task universe hello grab slush page exit update brisk
```
- Generate a new Rise address
```
 var secret = "cabbage chief join task universe hello grab slush page exit update brisk"; 
 var address = CryptoHelper.GetAddress(secret);
 //10861956178781184496L
 ```
- Sign and Verify message bytes
```
 var secret = "cabbage chief join task universe hello grab slush page exit update brisk"; 
 var address = CryptoHelper.GetAddress(secret);
 // address = { Id:"10861956178781184496L", KeyPair:{PublicKey:..., PrivateKey:...}}
 
 var keypair = address.KeyPair;
 var message = "This is my first message, testing sign and verify"
 var messageBytes = Encoding.UTF8.GetBytes(message);
 
 //Signs a message with private key
 
 var signatureBytes = CryptoHelper.Sign(messageBytes, keypair.PrivateKey);
 
 var signatureInHex = signatureBytes.ToHex();
 
 var isVerified = CryptoHelper.Verify(signatureBytes, keypair.PublicKey);
 //If isVerified = true, message verified correctly. 

 ```
- Public api examples

```
  IRiseNodeApi  _api = new RiseNodeApi(new ApiInfo
  {
      //Host = "yourhostip", // This can be any Rise node in the network, default is login.Rise.io
      //Port = "port"
        UseHttps = true
   });
  
  // gets peers from other Rise nodes,   /api/peers/
  var response = await _api.GetPeersAsync(); 
  
  // gets particular peer details from other nodes, /api/peers/get
  var response = await _api.GetPeerAsync(new PeerRequest
   {
      Ip = "104.251.218.222",
      Port = "8000"
   });
  
  // gets peer version from other Rise nodes, /api/peers/version
  var version = await _api.GetVersionAsync();
  
  // Opens an account session on other Rise nodes,  /api/accounts/open
  var response = await _api.OpenAccountAsync(new OpenAccountRequest
  {
      Secret= "cabbage chief join task universe hello grab slush page exit update brisk"
  });
  
  var _account = response.Account;
     
  // gets account balance from other Rise nodes,  /api/accounts/getBalance
  var response = await _api.GetAccountBalanceAsync(new AccountRequest
   {
     Address = _account.Address
   });
            
  // gets all the delegates, /api/delegates/
  var response = await _api.GetDelegatesAsync();
  
  // gets the delegate fee,  /api/delegates/fee
  var response = await _api.GetDelegateFeeAsync();
  
  // gets the signature fee,  /api/signatures/fee
  var response = await _api.GetSignatureFeeAsync();
  
  // gets the transaction details from a given transaction id, /api/transactions/get
  var response = await _api.GetTransactionAsync(new TransactionRequest
            {
            Id = "15748634892930294330"
            });
   
   More examples in unit tests.
  ...
  ```
- Peer api examples
```
IRisePeerApi  _api = new RisePeerApi(new ApiInfo
    {
        //Host = "yourhostip", // This can be any Rise node in the network, default is login.Rise.io
        //Port = "port"
        UseHttps = true
   });
            
 // gets peer list from other node, /peer/list           
 var response = await _api.GetPeerListAsync();            
 
 // gets peer height from other node, /peer/height
 var response = await _api.GetPeerHeightAsync();
 
 // gets peer blocks from other node, /peer/blocks
 var response = await _api.GetPeerBlocksAsync();
 
 //Send transaction
 var response = await _api.SendTransaction(new Transaction(){ Type = TransactionType.Send,  ... });
 
 
 //Vote transaction
 var response = await _api.VoteTransaction(new Transaciton({ Type = TransactionType.Vote, ....});
 
```
