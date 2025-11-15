$(function () {
    const form = $('#searchForm');
    const input = $('#searchInput');
    const inputName = 'SearchString';

    if (!form.length || !input.length) return;

    function ensureName() {
        if (!input.attr('name')) {
            input.attr('name', inputName);
        }
    }

    function removeName() {
        if (input.attr('name')) {
            input.removeAttr('name');
        }
    }

    if (typeof input.val() === 'string' && input.val().trim() === '') {
        input.val('');
        removeName();
    }

    input.on('input', function () {
        if (input.val().trim() === '') {
            input.val('');
            removeName();
            input.trigger('focus');
            form.trigger('submit');
        } else {
            ensureName();
        }
    });

    form.on('submit', function () {
        const val = (input.val() || '').trim();
        if (val === '') {
            input.val('');
            removeName();
        } else {
            input.val(val);
            ensureName();
        }
    });
});