<script>
window.openFileDialog = async () => {
    const input = document.createElement('input');
    input.type = 'file';
    input.accept = 'image/*';
    input.style.display = 'none';

    document.body.appendChild(input);

    console.log('openFileDialog function is being executed.');

    return new Promise((resolve) => {
        input.onchange = (e) => {
            const file = e.target.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = () => {
                    resolve(reader.result);
                };
                reader.readAsArrayBuffer(file);
            }
            document.body.removeChild(input);
        };

    input.click();
    });
};
</script>
