# Class with default necessary methods for fabric method create_serializer()
class CommonSerializer:
    def dump(self, obj, fp):
        """
        Serialize Python object to file
        :param obj: object which need to serialize
        :param fp: path to file which need to write python object
        :return: None
        """
        pass

    def dumps(self, obj):
        """
        Serialize Python object to string
        :param obj: object which need to serialize
        :return: serialized string
        """
        pass

    def load(self, fp):
        """
        Deserialize Python object from file
        :param fp: path to file where placed python object
        :return: python object
        """
        pass

    def loads(self, s):
        """
        Deserialize Python object from string
        :param s: string which contain python object in serialized view
        :return: python object
        """
        pass
