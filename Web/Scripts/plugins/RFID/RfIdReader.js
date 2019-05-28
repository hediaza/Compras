var RfIdReader = function () {
    "use strict"
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------
        connectionRfIdReader: null,
        hubRfIdReader: null,
        readTagEvent: null,
        connected: false,
        testMode: false,
        testTags: null,
        
        //..

        // ---------------------------------
        //           Metodos 
        // ---------------------------------
        init: function () {
            if (!RfIdReader.testMode) {
                RfIdReader.connectionRfIdReader = $.hubConnection("http://localhost:3331/signalr/hubs");
                RfIdReader.hubRfIdReader = RfIdReader.connectionRfIdReader.createHubProxy('morphoHub');
                RfIdReader.hubRfIdReader.on('SendTags', function (tags) {
                    RfIdReader.readTagEvent(tags);
                });
                var resultConnection = RfIdReader.connectionRfIdReader.start();
                RfIdReader.connected = true;
            }
            
        },

        capture: function () {
            
            if (!RfIdReader.testMode) {
                RfIdReader.hubRfIdReader.invoke('capture');
            } 
            else {
                if (RfIdReader.testTags == null) {
                    var numTags = Math.floor(Math.random() * 9 + 1);
                    var i;
                    var testTagsRandom = [];
                    for (i = 0; i < numTags; i++) {
                        var tagTest = '0000E2005100230702' + Math.floor(Math.random() * 90 + 10) + Math.floor(Math.random() * 90 + 10) + Math.floor(Math.random() * 90 + 10);
                        testTagsRandom.push(RfIdReader.hexToBase64(tagTest));
                    }

                    RfIdReader.readTagEvent(testTagsRandom);
                }
                else {
                    RfIdReader.readTagEvent(RfIdReader.testTags);
                }
            }

        },

        base64toHEX: function (base64) {
            var raw = atob(base64);
            var HEX = '';
            var i = 0;
            for (i = 0; i < raw.length; i++) {
                var _hex = raw.charCodeAt(i).toString(16)
                HEX += (_hex.length == 2 ? _hex : '0' + _hex);
            }
            return HEX.toUpperCase();
        },
        hexToBase64: function (hexstring) {
            return btoa(hexstring.match(/\w{2}/g).map(function (a) {
                return String.fromCharCode(parseInt(a, 16));
            }).join(""));
        }


    }
}();