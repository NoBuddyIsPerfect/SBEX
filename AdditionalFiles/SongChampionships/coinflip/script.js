const coin = document.querySelector('#coin');



function deferFn(callback, ms) {
  setTimeout(callback, ms); 
}

function processResult(result) {
	alertCoinFlipResult(result);
}

function flipCoin() {
  coin.setAttribute('class', '');
  const random = Math.random();
  const result = random < 0.5 ? 'right' : 'left';
 deferFn(function() {
   coin.setAttribute('class', 'animate-' + result);
   deferFn(processResult.bind(null, result), 9000);
 }, 100);
}


const WEBSOCKET_URI = 'ws://127.0.0.1:8080/';
const ACTION_ID = 'e9500661-3094-4ede-8ff9-5b3bcd6d0b7b';//'3324d8c7-429f-4f67-843d-e161c383f186';           

		   // -------------------------------------------------------
            // Called when the spin animation has finished by the callback feature of the wheel because I specified callback in the parameters
            // note the indicated segment is passed in as a parmeter as 99% of the time you will want to know this to inform the user of their prize.
            // -------------------------------------------------------
            function alertCoinFlipResult(indicatedSegment)
            {
                // Do basic alert of the segment text. You would probably want to do something more interesting with this information.
				let test = indicatedSegment;
              //  alert("1: "+test);
				console.log("You have won " + test);
				//document.getElementById('result').innerText = test;				
				let botCommand = JSON.stringify({ 
						 request: 'DoAction', 
						 id: 'DoAction', 
						 action: { 
						   id: ACTION_ID, 
						 }, 
						 args: { 
						   coinFlip: test 
						 } 
					 });
				//	 alert("2: "+test);
				const ws = new WebSocket(WEBSOCKET_URI); 
				 ws.addEventListener('open', function (event) { 
			//		 alert("3: "+test);
					 ws.send(botCommand);  
				 }); 
				<!-- alert(); -->
				
				
            }
		
			
flipCoin();