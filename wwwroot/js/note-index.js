document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('searchForm');
    const input = document.getElementById('searchInput');
    const inputName = 'SearchString';

    if (!form || !input) return;

    function ensureName() {
        if (!input.hasAttribute('name')) {
            input.setAttribute('name', inputName);
        }
    }

    function removeName() {
        if (input.hasAttribute('name')) {
            input.removeAttribute('name');
        }
    }

    if (typeof input.value === 'string' && input.value.trim() === '') {
        input.value = '';
        removeName();
    }

    input.addEventListener('input', function () {
        if (input.value.trim() === '') {
            input.value = '';
            removeName();
            input.focus();
            form.submit();
        } else {
            ensureName();
        }
    }, false);

    form.addEventListener('submit', function () {
        const val = (input.value || '').trim();
        if (val === '') {
            input.value = '';
            removeName();
        } else {
            input.value = val;
            ensureName();
        }
    }, false);
}, false);