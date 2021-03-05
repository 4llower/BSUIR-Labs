from ..serializers import JSONSerializer
from ..serializers import PICKLESerializer
from ..serializers import TOMLSerializer
from ..serializers import YAMLSerializer
from .supported_serializers import SupportedSerializers


def create_serializer(serializer_type):
    """
    Fabric method which create serializer with depends from object type
    :param serializer_type: string such as JSON | YAML | PICKLE | TOML
    :return: serializer which has methods from common_serializer
    """
    serializer_type_to_serializer_object = {
        SupportedSerializers.JSON: JSONSerializer(),
        SupportedSerializers.PICKLE: PICKLESerializer(),
        SupportedSerializers.TOML: TOMLSerializer(),
        SupportedSerializers.YAML: YAMLSerializer(),
    }

    if not serializer_type_to_serializer_object.get(serializer_type):
        raise ValueError("%s doesn't support" % serializer_type)

    return serializer_type_to_serializer_object[serializer_type]
