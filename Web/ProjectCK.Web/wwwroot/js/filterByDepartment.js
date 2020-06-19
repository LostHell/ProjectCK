function filterByDepartment(parameters) {
    const persons = document.querySelectorAll('tbody > tr');

    for (var i = 0; i < persons.length; i++) {

        const department = persons[i].getElementsByTagName('td')[4];

        if (parameters === 'all') {
            persons[i].style.display = '';
        }

        if (persons[i].style.display !== 'none' && parameters !== 'all') {

            if (parameters === 'it' && department.textContent.toLowerCase() === parameters) {
                persons[i].style.display = '';
            }
            else if (parameters === 'marketing' && department.textContent.toLowerCase() === parameters) {
                persons[i].style.display = '';
            }
            else if (parameters === 'logistic' && department.textContent.toLowerCase() === parameters) {
                persons[i].style.display = '';
            }
            else if (parameters === 'qa' && department.textContent.toLowerCase() === parameters) {
                persons[i].style.display = '';
            }
            else {
                persons[i].style.display = 'none';
            }
        }
    }
}