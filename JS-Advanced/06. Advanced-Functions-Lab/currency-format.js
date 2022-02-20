function createFormatter(separator,symbol,symbolFirst,formatter) {
    return (value) => formatter(separator,symbol,symbolFirst,value);
}