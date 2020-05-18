
(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement) {
            var options = {
                debug: 'info',
                modules: {
                    toolbar: '#toolbar'
                },
                placeholder: 'Write your training progress here...',
                readOnly: false,
                theme: 'snow'
            };            
            new Quill(quillElement, options);
        }        
    };
})();

