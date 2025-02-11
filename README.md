<p align="center"> 
<img src="KickLibLogo.png" style="max-height: 300px;">
</p>

<p align="center">
<a href="https://www.microsoft.com/net"><img src="https://img.shields.io/badge/-.NET%207.0-blueviolet" style="max-height: 300px;"></a>
<img src="https://img.shields.io/badge/Platform-.NET-lightgrey.svg" style="max-height: 300px;">
<a href="https://discord.gg/fPRXy57WrS"><img src="https://img.shields.io/badge/Discord-KickLib-green.svg" style="max-height: 300px;"></a>
<a href="https://github.com/Bukk94/KickLib/blob/master/LICENSE"><img src="https://img.shields.io/badge/License-MIT-yellow.svg" style="max-height: 300px;"></a>
<a href="https://www.nuget.org/packages/KickLib"><img src="https://img.shields.io/nuget/v/KickLib.svg?style=flat-square" style="max-height: 300px;"></a>
</p>

<p align="center">
  <a href='https://ko-fi.com/fusedchat' target='_blank'>
  <img height='30' style='border:0;height:38px;' src='https://az743702.vo.msecnd.net/cdn/kofi3.png?v=0' border='0' alt='Buy Me a Coffee at ko-fi.com' />
</a>

# About

KickLib is a C# library that allows for interaction with unofficial / undocumented Kick API (https://kick.com) 
 and WebSocket. KickLib eases implementation for various chatbots by providing simple to use methods.

## KickLib Highlights ✨
* Real-time chat reading
* Stream state detection
* Authentication flow
* Message sending
* Endpoint calls

<details>
<summary>Click here to see Complete Features List</summary>

### Client
* Reading Chat Messages
* Reading Channel events 
  * Follows status updated
  * Stream state detection

### API
* Clips
  * Get all Kick clips 
  * Get channel clips
  * Get clip information
  * Download clip
* Channels
  * Get channel information
  * Get latest subscriber
  * Get chatroom information
* Emotes
  * Get channel emotes
* Livestreams
  * Is streamer live?
  * Get livestream information 
* Message
  * Send message to chatroom
* Users
  * Get user information
</details>

## Installing ⏫

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). 
Then, install [KickLib](https://www.nuget.org/packages/KickLib) from the package manager console:

```
PM> Install-Package KickLib
```
Or from the .NET CLI as:
```
dotnet add package KickLib
```

## Examples 💡

### Using API to get information
```csharp
IKickApi kickApi = new KickApi();

var userName = "channelUsername";

// Get information about user
var user = await kickApi.Users.GetUserAsync(userName);

// Get information about channel
var channelInfo = await kickApi.Channels.GetChannelInfoAsync(userName);

// Gets detailed information about current livestream
var liveInfo = await kickApi.Livestream.GetLivestreamInfoAsync(userName);

// Get channel clips
var channelClips = await kickApi.Clips.GetChannelClipsAsync(userName);

// Authenticated calls
await kickApi.AuthenticateAsync("username", "password");
await kickApi.Messages.SendMessageAsync(123456, "My message");
```

### Using Client to read chat messages

```csharp
IKickClient client = new KickClient();

client.OnMessage += delegate(object sender, ChatMessageEventArgs e)
{
    Console.WriteLine(e.Data.Content);
};

await client.ListenToChatRoomAsync(123456);
await client.ConnectAsync();

```

## Custom downloader client

If you are not satisfied with provided client, you can implement your own download logic. 
All you need to do is implement `IApiCaller` interface and pass new instance to `KickApi`.

```csharp
public class MyOwnDownloader : IApiCaller 
{
    // Implementation
}
```
```csharp
var myDownloader = new MyOwnDownloader();
IKickApi kickApi = new KickApi(myDownloader);
```

# Disclaimer

Kick don't have any official API. All functionality in KickLib was researched and reversed-engineered from their website.
This means that any API can change without announce.

KickLib is meant to be used for education purposes. Don't use it for heavy scraping or other harmful actions against
Kick streaming platform. I don't take responsibility for any KickLib misuse and I strongly advice against such actions.

Once API is officially released, this library will be adjusted accordingly.

# License

See [MIT License](LICENSE).