function web() {
    return {
        type: 'copy',
        isfolder: true,
        source: '{0}\\Web'.format(set.VSVersion),
        target: 'Web'
    };
}