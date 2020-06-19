function filterByAge(parameters) {

    const range = parameters.split('-');

    let minAge = 0;
    let maxAge = 0;

    if (range.length === 2) {
        minAge = range[0];
        maxAge = range[1];
    }

    const persons = document.querySelectorAll('tbody > tr');

    for (var i = 0; i < persons.length; i++) {

        const age = persons[i].getElementsByTagName('td')[1];

        if (range[0] === 'all') {
            persons[i].style.display = '';
        }

        if (persons[i].style.display !== 'none' && range[0] !== 'all') {

            if (minAge <= age.textContent && maxAge >= age.textContent) {
                persons[i].style.display = '';
            }
            else if (range[0] === '51' && age.textContent >= range[0]) {
                persons[i].style.display = '';
            }
            else {
                persons[i].style.display = 'none';
            }
        }
    }
}