class NameTooShortError(Exception):
    pass


class MustContainAtSymbolError(Exception):
    pass


class InvalidDomainError(Exception):
    pass


valid_top_domains = ['com', 'bg', 'net', 'org']

while True:
    email = input()

    email_parts = email.split('@')

    if len(email_parts) == 1:
        raise MustContainAtSymbolError('Email must contain @')

    name, domain = email_parts

    domain_parts = domain.split('.')
    top_domain = domain_parts[1]

    if len(name) <= 4:
        raise NameTooShortError('Name must be more than 4 characters')

    if top_domain not in valid_top_domains:
        raise InvalidDomainError('Domain must be one of the following: .com, .bg, .org, .net')

