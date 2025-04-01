<html>
<head>
<style>
	body {background-color:#d2E0EF;}
	h2 {color: blue;}
	strong {color:blue;}
	* {font-family: Consolas;}
</style>
</head>
<body>
<h2>OTP QR Code for: {{user}}</h1>

<h3>Please scan the code with an Authenticator (Microsoft Authenticator, Google Authenticator, etc...)</h2>

<img alt='Embedded QR Code' width='200' src='data:image/jpg;base64,{{qrCodeBase64}}' />
<br/>
<p>Secret: {{Secret}}
<br/>
<p><a href='{{qrCodeUri}}'>Auth Link</a>
</body>
</html>