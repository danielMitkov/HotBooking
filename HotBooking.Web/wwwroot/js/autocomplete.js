$("#searchBar").autocomplete({
    source: function (request, response) {
        let controllerName = $('#urlInfo').attr('data-controllerName');
        let actionName = $('#urlInfo').attr('data-actionName');

        let url = `/${controllerName}/${actionName}/`;

        let searchTerm = $('#searchBar').val();

        $.ajax({
            url: url,
            data: { searchTerm: searchTerm },
            success: function (cities) {
                response(cities);
            }
        });
    },
    minLength: 2
});
