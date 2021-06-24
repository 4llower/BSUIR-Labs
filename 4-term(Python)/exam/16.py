import json


class LoadAttrs(type):
    def __init__(cls, name, bases, attrs):
        super(LoadAttrs, cls).__init__(name, bases, attrs)
        path = attrs['_attrs_file_path']
        extra_attrs = {}
        with open(path, 'r') as file:
            extra_attrs = json.load(file)
        for attr_name, attr_value in extra_attrs.items():
            setattr(cls, attr_name, attr_value)


class A(metaclass=LoadAttrs):
    _attrs_file_path = "attrs.json"
