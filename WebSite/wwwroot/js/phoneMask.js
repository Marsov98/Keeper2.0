window.applyPhoneMask = function (elementId) {
    var element = document.getElementById(elementId);

    if (element) {
        var phoneMask = function (event) {
            var input = event.target;
            var key = event.keyCode;
            var regex = /[0-9]/;

            if (regex.test(String.fromCharCode(key)) || key == 8 || key == 46) {
                var inputValue = input.value.replace(/\D/g, '');

                if (inputValue.length > 0 && inputValue[0] === '8') {
                    inputValue = '+7' + inputValue.slice(1);
                }

                var formattedValue = inputValue.replace(/^(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})$/, '+$1 ($2) $3-$4-$5');

                input.value = formattedValue;
            } else {
                event.preventDefault();
            }
        };

        element.addEventListener('input', phoneMask);
    }
};
