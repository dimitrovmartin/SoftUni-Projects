class Validator:
    @staticmethod
    def raise_if_str_is_empty_or_whitespace(value, error_message):
        if value.strip() == '':
            raise ValueError(error_message)

    @staticmethod
    def raise_if_price_is_negative_or_zero(value, error_message):
        if value <= 0:
            raise ValueError(error_message)
