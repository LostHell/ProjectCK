function filterByGender(parameters) {
    const persons = document.querySelectorAll('tbody > tr');

    for (var i = 0; i < persons.length; i++) {

        const gender = persons[i].getElementsByTagName('td')[2];

        persons[i].style.display = '';
            
        if (persons[i].style.display !== 'none' && parameters !== 'all') {

            if (parameters === 'male' && gender.textContent.toLowerCase() === parameters) {
                persons[i].style.display = '';
            } else if (parameters === 'female' && gender.textContent.toLowerCase() === parameters) {
                persons[i].style.display = '';
            } else {
                persons[i].style.display = 'none';
            }
        }
    }
}