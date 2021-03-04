from setuptools import setup, find_packages

setup(name="serialize_utility",
      packages=['local_packages', 'local_packages/factory', 'local_packages/serializers'],
      scripts=['bin/serialize'])
