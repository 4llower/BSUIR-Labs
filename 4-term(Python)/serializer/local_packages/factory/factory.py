from local_packages.serializers import JSONSerializer
from local_packages.serializers import PICKLESerializer
from local_packages.serializers import TOMLSerializer
from local_packages.serializers import YAMLSerializer


def create_serializer(serializer_type):
    """
    Fabric method which create serializer with depends from object type
    :param serializer_type: string such as JSON | YAML | PICKLE | TOML
    :return: serializer which has methods from common_serializer
    """
    serializer_type_to_serializer_object = {
        "JSON": JSONSerializer(),
        "PICKLE": PICKLESerializer(),
        "TOML": TOMLSerializer(),
        "YAML": YAMLSerializer(),
    }

    if not serializer_type_to_serializer_object.get(serializer_type):
        raise ValueError("%s doesn't support" % serializer_type)

    return serializer_type_to_serializer_object[serializer_type]
