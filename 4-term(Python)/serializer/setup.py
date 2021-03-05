from setuptools import setup

setup(name="serialize_utility",
      packages=['local_packages', 'local_packages/factory', 'local_packages/serializers', 'local_packages/helpers'],
      scripts=['bin/convert'])
