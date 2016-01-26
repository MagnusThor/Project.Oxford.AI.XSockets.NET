# Project.Oxford.AI.XSockets.NET

This is an example using [Project Oxford AI](https://www.projectoxford.ai/) Emotion API + XSockets.NET + WebRTC (getUserMedia)

##Quick about

This is a very brief descripton of the example/experiment

1. The "Camera" uses the [Navigator.getUserMedia API](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/getUserMedia) 

2. Captured put copied to a canvas (HTMLElement) from a `arrayBuffer` (Blob) is extracted
3. The Blob is passed using a XSockets.NET and a `XSockets.BinaryMessage`
4. The Message hits the Controller and is passed to the Emotion API using the `EmotionServiceClient`
5. The Emotion API returns a `emotionResult`
6. The `emotionResult` retrived and the` XSockets.BinaryMessage` analyzed is passed to all clients connected to at the moment.

** Nothing is preseved at the server side. 

----------

##Live example 

The example can be tested at the following link

[https://webrtoxfordai.azurewebsites.net/](https://webrtoxfordai.azurewebsites.net/)

* tested on Google Chrome, Firefox and Opera. It will probably run in IE Edge..
